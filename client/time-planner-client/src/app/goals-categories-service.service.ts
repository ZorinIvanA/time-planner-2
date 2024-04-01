import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class GoalsCategoriesService {
  constructor(private http: HttpClient) {
  }

  getGoalsCategories(): GoalsCategory[] {
    let categories: GoalsCategory[] = [];

    this.http.get<IResult<GoalsCategory>>('https://localhost:7049/api/Categories')
      .forEach(next => {
        next.result.forEach(element => {
          categories.push(element);
          console.log(element);
        });
      });

    return categories;
  }
}

export class GoalsCategory {
  name: string;
  id: string;

  constructor(name: string, id: string) {
    this.name = name;
    this.id = id;
  }
}

export interface IResult<Type> {
  result: Type[]
}
