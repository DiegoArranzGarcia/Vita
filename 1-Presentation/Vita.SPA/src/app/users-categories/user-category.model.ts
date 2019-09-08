import { User } from '../users/user.model';
import { Category } from '../categories/category.model';

export class UserCategory
{    
    public id: number;
    public user: User;
    public category: Category;
}