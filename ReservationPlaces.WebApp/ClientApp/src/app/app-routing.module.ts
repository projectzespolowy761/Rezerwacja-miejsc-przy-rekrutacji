import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './_guards';
import { HomeComponent } from './home';
import { LoginComponent } from './account-views/login/login.component';
import { RegisterComponent } from './account-views/register/register.component';
import { ConfirmEmailComponent } from './account-views/confirm-email/confirm-email.component';
import { ForgotPasswordComponent } from './account-views/forgot-password/forgot-password.component';
import { ForgotPasswordConfirmationComponent } from './account-views/forgot-password-confirmation/forgot-password-confirmation.component';
import { ResetPasswordConfirmationComponent } from './account-views/reset-password-confirmation/reset-password-confirmation.component';


const routes: Routes = [
  {
    path: '',
    canActivate: [AuthGuard],
    component: HomeComponent
  },
  {
    path: 'account', children: [
      { path: 'login', component: LoginComponent },
      { path: 'register', component: RegisterComponent },
      { path: 'confirm-email', component: ConfirmEmailComponent },
      { path: 'forgot-password', component: ForgotPasswordComponent },
      { path: 'forgot-password-confirmation', component: ForgotPasswordConfirmationComponent},
      { path: 'reset-password-confirmation', component: ResetPasswordConfirmationComponent },
    ]
  },

  // otherwise redirect to home
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
