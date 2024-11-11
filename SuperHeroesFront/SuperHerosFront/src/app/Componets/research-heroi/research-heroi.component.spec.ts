import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ResearchHeroiComponent } from './research-heroi.component';

describe('ResearchHeroiComponent', () => {
  let component: ResearchHeroiComponent;
  let fixture: ComponentFixture<ResearchHeroiComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ResearchHeroiComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ResearchHeroiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
