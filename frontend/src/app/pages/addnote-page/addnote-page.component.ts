import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { NoteserviceService } from '../../services/noteservice.service';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-addnote-page',
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './addnote-page.component.html',
  styleUrl: './addnote-page.component.css'
})
export class AddnotePage {
  noteForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private noteService: NoteserviceService,
    private router: Router
  ) {
    this.noteForm = this.fb.group({
      title: ['', [Validators.required, Validators.minLength(1)]],
      description: ['', [Validators.required, Validators.minLength(1)]],
    });
  }

  addNote() {
    if (this.noteForm.valid) {
      this.noteService.addNote(this.noteForm.value).subscribe({
        next: () => {
          alert('Note added successfully!');
          this.router.navigate(['/notes']);
        },
        error: (error) => console.error('Error adding note:', error),
      });
    }
  }
}
