import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http'
import { ModalModule} from 'ngx-bootstrap/modal';
import { TooltipModule} from 'ngx-bootstrap/tooltip';
import { BsDropdownModule} from 'ngx-bootstrap/dropdown';

import { AppComponent } from './app.component';
import { TodoComponent } from './todo/todo.component';
import { NavComponent } from './nav/nav.component';

@NgModule({
  declarations: [		
    AppComponent,
      TodoComponent,
      NavComponent
   ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    TooltipModule.forRoot(),
    ModalModule.forRoot(),
    BsDropdownModule.forRoot(),
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
