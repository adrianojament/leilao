import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { UserDto } from '../Interfaces/Users/UserDto';
import { UserDtoCreate } from '../Interfaces/Users/UserDtoCreate';
import { UserDtoUpdate } from '../Interfaces/Users/UserDtoUpdate';

const urlUser = '/api/v1/users';

@Injectable({
  providedIn: 'root',
})
export class UserServiceService {
  private URL: string;
  constructor(private http: HttpClient) {
    this.URL = environment.url_API + urlUser;
  }

  getAllUsers(): Observable<UserDto[]> {
    return this.http.get<UserDto[]>(this.URL);
  }

  postUser(user: UserDtoCreate): Observable<UserDto> {
    return this.http.post<UserDto>(this.URL, user);
  }

  getUser(id: string): Observable<UserDto> {
    return this.http.get<UserDto>(`${this.URL}/${id}`);
  }

  putUser(id: string, user: UserDtoUpdate): Observable<UserDto> {
    return this.http.put<UserDto>(`${this.URL}/${id}`, user);
  }

  removeUser(id: string): Observable<UserDto> {
    return this.http.delete<UserDto>(`${this.URL}/${id}`);
  }
}
