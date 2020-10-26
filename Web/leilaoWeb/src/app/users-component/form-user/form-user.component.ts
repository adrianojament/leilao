import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import { Component, Inject, OnInit } from '@angular/core';
import {
  AbstractControl,
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

import { UserController } from 'src/app/Controllers/user-controller';
import { UserDto } from 'src/app/Interfaces/Users/UserDto';
import { ConfirmedValidator } from './confirmed.validator';

@Component({
  selector: 'app-form-user',
  templateUrl: './form-user.component.html',
  styleUrls: ['./form-user.component.css'],
})
export class FormUserComponent implements OnInit {
  hide = true;
  userForm = new FormGroup({});
  ErrorMessage = '';
  isError = false;
  isNewUser = false;

  constructor(
    public dialogRef: MatDialogRef<FormUserComponent>,
    @Inject(MAT_DIALOG_DATA) public data: UserDto,
    private fb: FormBuilder,
    private userController: UserController
  ) {
    this.isNewUser = data.id.length === 0;

    if (this.isNewUser) {
      this.UserNewGroup();
    } else {
      this.UserEditGroup();
    }
  }

  private UserNewGroup(): void {
    this.userForm = this.fb.group(
      {
        name: new FormControl('', [
          Validators.required,
          Validators.maxLength(60),
        ]),
        email: new FormControl('', [
          Validators.required,
          Validators.maxLength(100),
          Validators.email,
        ]),
        password: new FormControl('', [
          Validators.required,
          Validators.maxLength(20),
          Validators.minLength(6),
        ]),
        confirmPassword: new FormControl('', Validators.required),
      },
      {
        validators: ConfirmedValidator('password', 'confirmPassword'),
      }
    );
  }

  UserEditGroup(): void {
    this.userForm = this.fb.group({
      name: new FormControl(this.data.name, [
        Validators.required,
        Validators.maxLength(60),
      ]),
      email: new FormControl({ value: this.data.email, disabled: true }),
      password: new FormControl({ value: this.data.password, disabled: true }),
      confirmPassword: new FormControl({
        value: this.data.password,
        disabled: true,
      }),
    });
  }

  ngOnInit(): void {
    if (!this.isNewUser) {
      this.userController
        .getUser(this.data.id)
        .then((u) => {
          this.data = u;
          this.name.setValue(u.name);
          this.email.setValue(u.email);
          this.password.setValue(u.password);
          this.confirmPassword.setValue(u.password);
        })
        .catch((e) => {
          this.isError = true;
          this.ErrorMessage = e.error;
        });
    }
  }

  get name(): AbstractControl {
    return this.userForm.get('name');
  }

  get email(): AbstractControl {
    return this.userForm.get('email');
  }

  get password(): AbstractControl {
    return this.userForm.get('password');
  }

  get confirmPassword(): AbstractControl {
    return this.userForm.get('confirmPassword');
  }

  saveUser(): void {
    this.isError = !this.Validate();
    if (this.isError) {
      return;
    }

    if (this.isNewUser) {
      this.NewUser();
    } else {
      this.EditUser();
    }
  }
  EditUser(): void {
    const user = {
      id: this.data.id,
      name: this.name.value,
      email: this.data.email,
      password: this.data.password,
    };

    this.userController
      .putUser(this.data.id, user)
      .then((u) => {
        this.dialogRef.close(u);
      })
      .catch((e) => {
        this.isError = true;
        this.ErrorMessage = e.error;
      });
  }

  private NewUser(): void {
    const valueForm = this.userForm.value;

    const { name, email, password } = valueForm;

    const user = { name, email, password };

    this.userController
      .postUser(user)
      .then((u) => {
        this.dialogRef.close(u);
      })
      .catch((e) => {
        this.isError = true;
        this.ErrorMessage = e.error;
      });
  }

  Validate(): boolean {
    if (this.name.errors && this.name.errors.required) {
      this.ErrorMessage = 'Informe o nome';
      return false;
    }

    if (this.email.errors && this.email.errors.required) {
      this.ErrorMessage = 'Informe o e-Mail';
      return false;
    }

    if (this.email.errors && this.email.errors.email) {
      this.ErrorMessage = 'e-Mail inválido.';
      return false;
    }

    if (
      this.password.errors &&
      (this.password.errors.required ||
        this.password.errors.maxLength ||
        this.password.errors.minLength)
    ) {
      this.ErrorMessage = 'Senha inválida.';
      return false;
    }

    if (
      this.confirmPassword.errors &&
      (this.confirmPassword.errors.required ||
        this.confirmPassword.errors.confirmedValidator)
    ) {
      this.ErrorMessage = 'Senha inválida.';
      return false;
    }

    return true;
  }

  onClose(): void {
    this.dialogRef.close();
  }
}
