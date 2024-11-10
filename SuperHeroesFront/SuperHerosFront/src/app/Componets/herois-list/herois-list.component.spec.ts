import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HeroisListComponent } from './herois-list.component';

describe('HeroisListComponent', () => {
  let component: HeroisListComponent;
  let fixture: ComponentFixture<HeroisListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [HeroisListComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HeroisListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
