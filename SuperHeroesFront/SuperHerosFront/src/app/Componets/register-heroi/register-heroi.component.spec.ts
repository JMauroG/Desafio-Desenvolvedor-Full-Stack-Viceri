import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegisterHeroiComponent } from './register-heroi.component';

describe('RegisterHeroiComponent', () => {
  let component: RegisterHeroiComponent;
  let fixture: ComponentFixture<RegisterHeroiComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [RegisterHeroiComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RegisterHeroiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
