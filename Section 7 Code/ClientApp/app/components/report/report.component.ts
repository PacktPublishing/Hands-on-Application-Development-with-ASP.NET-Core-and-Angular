import { OrderService } from './../../services/order.service';
import { Component, OnInit } from '@angular/core';
import { ReactiveFormsModule, FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-report',
  templateUrl: './report.component.html'
})
export class ReportComponent implements OnInit {

    orders: any;

    constructor(private orderService: OrderService){}

    ngOnInit() {
        this.orderService.getOrders().subscribe(o => {
            this.orders = o.result;
            console.log(this.orders);
        });
    }
}
