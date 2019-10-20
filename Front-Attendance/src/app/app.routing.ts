import { Routes, RouterModule, PreloadAllModules  } from '@angular/router';
import { ModuleWithProviders } from '@angular/core';
import { HomeComponent } from './home/home.component';
import { NotFoundComponent } from './error-pages/not-found/not-found.component';
import { InternalServerComponent } from './error-pages/internal-server/internal-server.component';


export const routes: Routes = [
    { path: 'home', component: HomeComponent },
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