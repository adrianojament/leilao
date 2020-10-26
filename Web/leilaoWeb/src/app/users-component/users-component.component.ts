import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { UserController } from '../Controllers/user-controller';
import { UserDto } from '../Interfaces/Users/UserDto';
import { FormUserComponent } from './form-user/form-user.component';

@Component({
  selector: 'app-users-component',
  templateUrl: './users-component.component.html',
  styleUrls: ['./users-component.component.css'],
})
export class UsersComponentComponent implements OnInit {
  users: UserDto[] = [];
  json: string;
  error: boolean;
  findingdata = true;
  message: string;

  constructor(
    private userController: UserController,
    // tslint:disable-next-line: variable-name
    private _snackBar: MatSnackBar,
    public dialog: MatDialog
  ) {}

  ngOnInit(): void {
    this.error = false;
    this.findingdata = true;
    this.userController
      .getAllUser()
      .then((users) => {
        this.findingdata = false;
        this.users = users;
        this.OrderList();
      })
      .catch((error) => {
        this.findingdata = false;
        this.error = true;
        this.message = error;
        this.openSnackBar();
      });
  }

  openSnackBar(): void {
    this._snackBar.open('Erro', this.message, {
      duration: 90000,
      horizontalPosition: 'center',
      verticalPosition: 'top',
    });
  }

  callFormUser(id: string): void {
    const dialogRef = this.dialog.open(FormUserComponent, {
      width: '600px',
      height: '350px',
      data: { id },
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        // tslint:disable-next-line: no-shadowed-variable
        const { id, name, email, password } = result;
        const user: UserDto = { id, name, email, password };
        this.users = this.users.filter((us) => us.id !== id);
        this.users = [...this.users, user];
        this.OrderList();
      }
    });
  }

  private OrderList(): void {
    this.users.sort((a, b) => {
      const textA = a.name.toUpperCase();
      const textB = b.name.toUpperCase();
      return textA < textB ? -1 : textA > textB ? 1 : 0;
    });
  }

  NewUser(): void {
    this.callFormUser('');
  }

  remove(Id: string): void {
    this.userController
      .removeUser(Id)
      .then((_) => {
        this.users = this.users.filter((us) => us.id !== Id);
        this.OrderList();
      })
      .catch((error) => {
        this.error = true;
        this.message = error;
        this.openSnackBar();
      });
  }

  alterUser(Id: string): void {
    this.callFormUser(Id);
  }
}
