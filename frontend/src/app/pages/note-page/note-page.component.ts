import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NoteserviceService } from '../../services/noteservice.service';
import { Note } from '../../interfaces/note.model';

@Component({
  selector: 'app-note-page',
  imports: [],
  templateUrl: './note-page.component.html',
  styleUrl: './note-page.component.css'
})
export class NotePageComponent implements OnInit {

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

}
