import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UptadeHeroiComponent } from './uptade-heroi.component';

describe('UptadeHeroiComponent', () => {
  let component: UptadeHeroiComponent;
  let fixture: ComponentFixture<UptadeHeroiComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [UptadeHeroiComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UptadeHeroiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
