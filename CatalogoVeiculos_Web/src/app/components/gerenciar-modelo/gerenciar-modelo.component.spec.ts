import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GerenciarModeloComponent } from './gerenciar-modelo.component';

describe('GerenciarModeloComponent', () => {
  let component: GerenciarModeloComponent;
  let fixture: ComponentFixture<GerenciarModeloComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GerenciarModeloComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GerenciarModeloComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
