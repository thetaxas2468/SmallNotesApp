import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { Router, RouterModule } from '@angular/router'; // Import Router for navigation

@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.css'],
  imports: [CommonModule, RouterModule],
})
export class Homepage {
  constructor(private router: Router) { }

  navigateToAddNote() {
    this.router.navigate(['/add-note']);
  }

  navigateToShowNotes() {
    this.router.navigate(['/notes']);
  }
}
