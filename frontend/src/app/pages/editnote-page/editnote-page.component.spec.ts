import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditnotePage as EditnotePageComponent } from './editnote-page.component';

describe('EditnotePageComponent', () => {
  let component: EditnotePageComponent;
  let fixture: ComponentFixture<EditnotePageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EditnotePageComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditnotePageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
