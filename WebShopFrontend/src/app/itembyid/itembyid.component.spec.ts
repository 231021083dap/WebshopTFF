import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ItembyidComponent } from './itembyid.component';

describe('ItembyidComponent', () => {
  let component: ItembyidComponent;
  let fixture: ComponentFixture<ItembyidComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ItembyidComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ItembyidComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
