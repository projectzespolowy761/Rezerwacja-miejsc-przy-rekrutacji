import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ConfirmedEmailComponent } from './confirmed-email/confirmed-email.component';
import { ConfirmEmailComponent } from './confirm-email/confirm-email.component';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';
import { ForgotPasswordConfirmationComponent } from './forgot-password-confirmation/forgot-password-confirmation.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { ResetPasswordComponent } from './reset-password/reset-password.component';
import { ResetPasswordConfirmationComponent } from './reset-password-confirmation/reset-password-confirmation.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    ConfirmedEmailComponent,
    ConfirmEmailComponent,
    ForgotPasswordComponent,
    ForgotPasswordConfirmationComponent,
    LoginComponent,
    RegisterComponent,
    ResetPasswordComponent,
    ResetPasswordConfirmationComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule
  ],
  exports: [
    ConfirmedEmailComponent,
    ConfirmEmailComponent,
    ForgotPasswordComponent,
    ForgotPasswordConfirmationComponent,
    LoginComponent,
    RegisterComponent,
    ResetPasswordComponent,
    ResetPasswordConfirmationComponent
  ]
})
export class AccountViewsModule { }
