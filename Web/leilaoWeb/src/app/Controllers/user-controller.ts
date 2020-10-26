import { Injectable } from '@angular/core';
import { UserDto } from '../Interfaces/Users/UserDto';
import { UserDtoCreate } from '../Interfaces/Users/UserDtoCreate';
import { UserDtoUpdate } from '../Interfaces/Users/UserDtoUpdate';
import { UserServiceService } from '../Services/user-service.service';

@Injectable({
  providedIn: 'root',
})
export class UserController {
  users: UserDto[] = [];

  constructor(private userService: UserServiceService) {}

  // tslint:disable-next-line: typedef
  getAllUser() {
    return this.userService.getAllUsers().toPromise();
  }

  // tslint:disable-next-line: typedef
  postUser(user: UserDtoCreate) {
    return this.userService.postUser(user).toPromise();
  }

  // tslint:disable-next-line: typedef
  getUser(id: string) {
    return this.userService.getUser(id).toPromise();
  }

  // tslint:disable-next-line: typedef
  putUser(id: string, user: UserDtoUpdate) {
    return this.userService.putUser(id, user).toPromise();
  }

  // tslint:disable-next-line: typedef
  removeUser(id: string) {
    return this.userService.removeUser(id).toPromise();
  }
}
