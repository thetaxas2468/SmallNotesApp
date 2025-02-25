import { CommonModule } from '@angular/common';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Component } from '@angular/core';
import { NoteserviceService } from '../../services/noteservice.service';
import { Note } from '../../interfaces/note.model';
import { NoteComponent } from '../../components/note/note.component';

@Component({
  selector: 'app-notespage',
  imports: [CommonModule, HttpClientModule, NoteComponent],
  templateUrl: './notespage.component.html',
  styleUrl: './notespage.component.css'
})
export class Notespage {
  notes: Note[] = [];
  constructor(private notesService: NoteserviceService) { }

  ngOnInit() {
    this.loadNotes();
  }

  loadNotes() {
    this.notesService.fetchNotes().subscribe({
      next: (data) => {
        this.notes = data;
      },
      error: (error) => {
        console.error('Error fetching notes:', error);
      }
    });
  }

}
