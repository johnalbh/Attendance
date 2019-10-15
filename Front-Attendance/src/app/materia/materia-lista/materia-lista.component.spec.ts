import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MateriaListaComponent } from './materia-lista.component';

describe('MateriaListaComponent', () => {
  let component: MateriaListaComponent;
  let fixture: ComponentFixture<MateriaListaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MateriaListaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MateriaListaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
