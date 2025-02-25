import { NoteComponent } from './components/note/note.component';
import { AddnotePage } from './pages/addnote-page/addnote-page.component';
import { EditnotePage } from './pages/editnote-page/editnote-page.component';
import { Homepage } from './pages/homepage/homepage.component';
import { NotePageComponent } from './pages/note-page/note-page.component';
import { Notespage } from './pages/notespage/notespage.component';
import { Routes } from '@angular/router';

export const routes: Routes = [
    {
        path: "", component: Homepage,
    },
    {
        path: "notes", component: Notespage
    },
    { path: 'add-note', component: AddnotePage },
    {
        path: "edit-note/:id", component: EditnotePage
    },
    {
        path: "show-note/:id", component: NotePageComponent
    }
];
