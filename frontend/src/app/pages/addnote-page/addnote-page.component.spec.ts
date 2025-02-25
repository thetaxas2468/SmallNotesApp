import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddnotePage as AddnotePageComponent } from './addnote-page.component';

describe('AddnotePageComponent', () => {
  let component: AddnotePageComponent;
  let fixture: ComponentFixture<AddnotePageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AddnotePageComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddnotePageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
