import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NoteserviceService } from '../../services/noteservice.service';
import { Note } from '../../interfaces/note.model';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-addnote-page',
  templateUrl: './editnote-page.component.html',
  styleUrls: ['./editnote-page.component.css'],
  imports: [CommonModule, ReactiveFormsModule, FormsModule]
})
export class EditnotePage implements OnInit {
  noteId: number | null = null;
  note: Note = {
    title: '', description: '',
    id: -1,
    created: new Date(),
  };

  constructor(
    private route: ActivatedRoute,
    private notesService: NoteserviceService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.noteId = parseInt(this.route.snapshot.paramMap.get('id')!, 10);

    if (this.noteId) {
      this.notesService.getNoteById(this.noteId).subscribe({
        next: (note: Note) => {
          this.note = note;
        },
        error: (error: any) => {
          console.error('Error fetching note:', error);
        },
      });
    }
  }

  saveNote() {
    if (this.noteId) {
      this.notesService.updateNoteById(this.noteId, this.note).subscribe({
        next: () => {
          alert('Note updated successfully!');
          this.router.navigate(['/notes']);
        },
        error: (error: any) => {
          console.error('Error updating note:', error);
        },
      });
    } else {
      this.router.navigate(["/"]);
    }
  }
}
