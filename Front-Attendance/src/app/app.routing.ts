import { Routes, RouterModule, PreloadAllModules  } from '@angular/router';
import { ModuleWithProviders } from '@angular/core';
import { NotFoundComponent } from './error-pages/not-found/not-found.component';
import { InternalServerComponent } from './error-pages/internal-server/internal-server.component';
import { AuthGuard } from './auth/auth.guard';
import { ForbiddenComponent } from './forbidden/forbidden.component';


export const routes: Routes = [
    { path: 'user', loadChildren: './user/user.module#UserModule' },
    { path: 'home', loadChildren: './home/home.module#HomeModule' },
    { path: 'administrador', loadChildren: './administrador/administrador.module#AdministradorModule', 
        canActivate: [AuthGuard], data : {permittedRoles: ['Administrador']} 
    },
    { path: 'forbidden', component: ForbiddenComponent },
    { path: '404', component : NotFoundComponent},
    { path: '500', component: InternalServerComponent },
    { path: '', redirectTo: 'user/login', pathMatch: 'full' },
    { path: '**', redirectTo: '/404', pathMatch: 'full'}
];

export const Routing: ModuleWithProviders = RouterModule.forRoot(routes, {
    // preloadingStrategy: PreloadAllModules,  // <- uncomment this line for disable lazy load
    // useHash: true
});