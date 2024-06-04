import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddtofavComponent } from './addtofav.component';

describe('AddtofavComponent', () => {
  let component: AddtofavComponent;
  let fixture: ComponentFixture<AddtofavComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AddtofavComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AddtofavComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
