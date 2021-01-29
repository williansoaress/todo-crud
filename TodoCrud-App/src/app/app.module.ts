import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http'
import { ReactiveFormsModule } from '@angular/forms';

import { ModalModule} from 'ngx-bootstrap/modal';
import { TooltipModule} from 'ngx-bootstrap/tooltip';
import { BsDropdownModule} from 'ngx-bootstrap/dropdown';
import { BsDatepickerModule} from 'ngx-bootstrap/datepicker';
import { ToastrModule } from 'ngx-toastr';

import { AppComponent } from './app.component';
import { TodoComponent } from './todo/todo.component';
import { NavComponent } from './nav/nav.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { UserComponent } from './user/user.component';
import { AppRoutingModule } from './app-routing.module';
import { TitleComponent } from './_shared/title/title.component';

@NgModule({
  declarations: [				
    AppComponent,
      TodoComponent,
      NavComponent,
      DashboardComponent,
      UserComponent,
      TitleComponent
   ],
  imports: [
    BrowserModule,
    BsDatepickerModule.forRoot(),
    TooltipModule.forRoot(),
    ModalModule.forRoot(),
    BsDropdownModule.forRoot(),
    BrowserAnimationsModule,
    ToastrModule.forRoot(), 
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
