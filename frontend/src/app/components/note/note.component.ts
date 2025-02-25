import { Component, Input, OnInit } from '@angular/core';
import { Note } from '../../interfaces/note.model';
import { ActivatedRoute, Router } from '@angular/router';
import { NoteserviceService } from '../../services/noteservice.service';

@Component({
  selector: 'app-note',
  imports: [],
  templateUrl: './note.component.html',
  styleUrl: './note.component.css'
})
export class NoteComponent {

  @Input() note!: Note;

  constructor(private router: Router, private notesService: NoteserviceService, private route: ActivatedRoute) { }




  editNote(event: Event) {
    event.stopPropagation();
    this.router.navigate([`/edit-note/${this.note.id}`]);
  }

  // Delete the note
  deleteNote(event: Event) {
    event.stopPropagation();
    this.notesService.deleteNoteById(this.note.id).subscribe({
      next: () => {
        alert('Note deleted successfully!');
        window.location.reload();
      },
      error: (error: any) => {
        console.error('Error deleting note:', error);
      },
    });
  }

  onNoteClick(event: Event) {
    event.stopPropagation();
    this.router.navigate([`/show-note/${this.note.id}`]);
  }

}
