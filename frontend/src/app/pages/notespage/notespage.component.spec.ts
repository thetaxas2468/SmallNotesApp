import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Notespage as NotespageComponent } from './notespage.component';

describe('NotespageComponent', () => {
  let component: NotespageComponent;
  let fixture: ComponentFixture<NotespageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [NotespageComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NotespageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
