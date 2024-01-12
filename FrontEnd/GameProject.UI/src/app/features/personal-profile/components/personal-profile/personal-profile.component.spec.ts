import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PersonalProfileComponent } from './personal-profile.component';

describe('PersonalProfileComponent', () => {
  let component: PersonalProfileComponent;
  let fixture: ComponentFixture<PersonalProfileComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [PersonalProfileComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PersonalProfileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
