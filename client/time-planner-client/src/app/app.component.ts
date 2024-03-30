import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { GoalsCategoriesComponent } from './goals-categories/goals-categories.component';

@Component({
    selector: 'app-root',
    standalone: true,
    templateUrl: './app.component.html',
    styleUrl: './app.component.sass',
    imports: [RouterOutlet, GoalsCategoriesComponent]
})
export class AppComponent {
  title = 'time-planner-client';
}
