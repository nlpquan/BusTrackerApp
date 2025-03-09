import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BusRouteSearchComponent } from './bus-route-search.component';

describe('BusRouteSearchComponent', () => {
  let component: BusRouteSearchComponent;
  let fixture: ComponentFixture<BusRouteSearchComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BusRouteSearchComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BusRouteSearchComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
