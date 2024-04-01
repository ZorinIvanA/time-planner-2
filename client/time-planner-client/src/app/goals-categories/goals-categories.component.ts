import { Component } from '@angular/core';
import { GoalsCategoriesService, GoalsCategory } from '../goals-categories-service.service';
import { NgFor } from '@angular/common';
import { HttpClientModule   } from '@angular/common/http';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-goals-categories',
  standalone: true,
  imports: [NgFor],
  templateUrl: './goals-categories.component.html',
  styleUrl: './goals-categories.component.sass',
  providers: [HttpClientModule ]
})
export class GoalsCategoriesComponent {
  categories: GoalsCategory[];

  constructor(private service: GoalsCategoriesService ) {
    this.categories = this.service.getGoalsCategories();
  }
}
