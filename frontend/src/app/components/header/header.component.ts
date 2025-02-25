import { Component } from '@angular/core';
import { Route, Router } from '@angular/router';

@Component({
  selector: 'app-header',
  imports: [],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent {

  constructor(private router: Router) { }
  navigateToHome() {
    this.router.navigate(['/']);
  }
  navigateToAddNote() {
    this.router.navigate(['/add-note']);
  }
  navigateToAllNotes() {
    this.router.navigate(['/notes']);
  }
}
