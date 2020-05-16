import { Component, OnInit } from '@angular/core';
import { CategoryService } from '../categories/category.service';
import { UserService } from '../users/user.service';
import { Category } from '../categories/category.model';
import { faCircle } from '@fortawesome/free-solid-svg-icons';

@Component({
    selector: 'goal-list-create-item',
    templateUrl: './goal-list-create-item.component.html',
    styleUrls: ['./goal-list-create-item.component.scss']
})

export class GoalListCreateItemComponent implements OnInit {

    categories: Category[];
    selectedCategory: Category;
    selectedCategoryIcon = faCircle;

    constructor(private categoryService: CategoryService,
                private userService: UserService)
    {

    }

    ngOnInit()
    {
        this.categoryService.getAllCategoriesOfUser(this.userService.getCurrentUser().id)
                            .subscribe(categories => this.categories = categories);
    }

    onSelectedCategory(category: Category){
        this.selectedCategory = category;
    }

}