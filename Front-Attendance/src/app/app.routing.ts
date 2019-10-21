import { Routes, RouterModule, PreloadAllModules  } from '@angular/router';
import { ModuleWithProviders } from '@angular/core';
import { HomeComponent } from './home/home.component';
import { NotFoundComponent } from './error-pages/not-found/not-found.component';
import { InternalServerComponent } from './error-pages/internal-server/internal-server.component';
import { AuthGuard } from './auth/auth.guard';
import { AdministradorComponent } from './administrador/administrador.component';
import { ForbiddenComponent } from './forbidden/forbidden.component';


export const routes: Routes = [
    { path: 'home', component: HomeComponent, canActivate: [AuthGuard] },
    { path: 'administrador', component: AdministradorComponent, canActivate: [AuthGuard], data : {permittedRoles: ['Administrador']}  },
    { path: 'forbidden', component: ForbiddenComponent },
    { path: '404', component : NotFoundComponent},
    { path: '500', component: InternalServerComponent },
    { path: 'materia', loadChildren: "./materia/materia.module#MateriaModule" },
    { path: 'user', loadChildren: "./user/user.module#UserModule" },
    { path: '', redirectTo: 'user/registro', pathMatch: 'full' },
    { path: '**', redirectTo: '/404', pathMatch: 'full'}
];

export const Routing: ModuleWithProviders = RouterModule.forRoot(routes, {
    // preloadingStrategy: PreloadAllModules,  // <- uncomment this line for disable lazy load
    // useHash: true
});