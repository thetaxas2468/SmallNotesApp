import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Note } from "../interfaces/note.model";

@Injectable({
  providedIn: 'root'
})
export class NoteserviceService {
  notes: Note[] = [];
  private apiUrl = 'https://localhost:7123/api/Notes';

  constructor(private http: HttpClient) { }


  fetchNotes(): Observable<Note[]> {
    return this.http.get<Note[]>(this.apiUrl);
  }

  addNote(note: { description: string, title: string }) {
    return this.http.post(this.apiUrl, note);
  }

  deleteNoteById(id: number) {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }

  getNoteById(noteId: number): Observable<any> {
    return this.http.get<Note>(`${this.apiUrl}/${noteId}`);
  }

  updateNoteById(noteId: number, note: Note): Observable<any> {
    return this.http.put<any>(`${this.apiUrl}/edit/${noteId}`, note);
  }
}
