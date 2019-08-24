import { Injectable } from '@angular/core';
import { Category } from './category.model';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor() { 
  }

  public getCategories() : Category[]  {
    return [
      { name: "Cooking", color: "skyblue", isDefaultCategory: true },
      { name: "Sports", color: "crimson", isDefaultCategory: true },
      { name: "VideoGames", color:"darkorange", isDefaultCategory: true },
      { name: "Travel", color:"lightslategray", isDefaultCategory: true },
      { name: "Study", color:"deeppink", isDefaultCategory: true },
      { name: "TV Series", color:"springgreen", isDefaultCategory: true },
      { name: "Movies", color:"turquoise", isDefaultCategory: true },
      { name: "Books", color:"darkslateblue", isDefaultCategory: true },
      { name: "Music", color:"limegreen", isDefaultCategory: true },
      { name: "Places", color:"lightseagreen", isDefaultCategory: true },
      { name: "Podcasts", color:"darkcyan", isDefaultCategory: true },
      { name: "Bar & Clubs", color:"dodgerblue", isDefaultCategory: true },
      { name: "Restaurants", color:"tomato", isDefaultCategory: true },
    ];
  }
}
