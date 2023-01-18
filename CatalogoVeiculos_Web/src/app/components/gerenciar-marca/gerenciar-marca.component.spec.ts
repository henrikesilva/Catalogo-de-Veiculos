import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GerenciarMarcaComponent } from './gerenciar-marca.component';

describe('GerenciarMarcaComponent', () => {
  let component: GerenciarMarcaComponent;
  let fixture: ComponentFixture<GerenciarMarcaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GerenciarMarcaComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GerenciarMarcaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
