import { DefaultDtoController } from '../Standard/DefaultDtoController';
import { UserDto } from './UserDto';

export interface UserDtoController extends DefaultDtoController {
  Users: UserDto[];
}
