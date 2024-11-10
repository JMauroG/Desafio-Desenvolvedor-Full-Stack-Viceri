import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteHeroiComponent } from './delete-heroi.component';

describe('DeleteHeroiComponent', () => {
  let component: DeleteHeroiComponent;
  let fixture: ComponentFixture<DeleteHeroiComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [DeleteHeroiComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DeleteHeroiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
