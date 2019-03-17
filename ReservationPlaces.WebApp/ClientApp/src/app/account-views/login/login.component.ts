import { Component, OnInit, AfterViewInit} from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import { AuthenticationService } from 'src/app/_services';
import { trigger, style, state, transition, animate, stagger, query } from '@angular/animations';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
  animations: [
    trigger('OnLoad', [
      transition('*=>*', [
        query('div', style({ opacity: '0.0'})),
        query(':self', style({transform: 'translateY(-30%)'})),
        query(':self', animate('500ms', style({transform: 'translateY(0)'}))),
        query('div', stagger('150ms', animate('500ms', style({ opacity: '1'}))), )
      ])
    ]),
  ]
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  loading = false;
  submitted = false;
  returnUrl: string;
  errors: string[];
  rememberMe = false;


  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private authenticationService: AuthenticationService) { }




  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      username: ['', [Validators.required, Validators.pattern('[a-zA-Z0-9.-_]{1,}@[a-zA-Z.-]{2,}[.]{1}[a-zA-Z]{2,}')]],
      password: ['', [Validators.required, Validators.minLength(6)]],
    });

    // reset login status
    this.authenticationService.logout();

    // get return url from route parameters or default to '/'
    this.returnUrl = this.route.snapshot.queryParams.returnUrl || '/';

    this.errors = [];
  }


  rememberMeFunc() {
    this.rememberMe = !this.rememberMe;
  }


  // convenience getter for easy access to form fields
  get f() { return this.loginForm.controls; }

  onSubmit() {
    this.submitted = true;
    this.errors = [];

    // stop here if form is invalid
    if (this.loginForm.invalid) {
      return;
    }

    this.loading = true;
    this.authenticationService.login(this.f.username.value, this.f.password.value, this.rememberMe)
      .pipe(first())
      .subscribe(
        data => {
          this.router.navigate([this.returnUrl]);
        },
      error => {
        console.log(error);
        this.loading = false;
        if (error.status === 400) {
          // handle validation error
          const validationErrorDictionary = JSON.parse(error.text());
          for (const fieldName in validationErrorDictionary) {
            if (validationErrorDictionary.hasOwnProperty(fieldName)) {
              this.errors.push(validationErrorDictionary[fieldName]);
            }
          }
        } else {
          this.errors.push('Coś poszło nie tak!');
        }
        console.log(this.errors);
      });
  }
}
