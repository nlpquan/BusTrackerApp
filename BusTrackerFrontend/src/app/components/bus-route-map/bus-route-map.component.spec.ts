import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BusRouteMapComponent } from './bus-route-map.component';

describe('BusRouteMapComponent', () => {
  let component: BusRouteMapComponent;
  let fixture: ComponentFixture<BusRouteMapComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BusRouteMapComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BusRouteMapComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
