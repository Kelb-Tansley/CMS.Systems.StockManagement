import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { Observable, Subscription } from 'rxjs';
import { map } from 'rxjs/operators';
import { AuthorizeService } from 'src/api-authorization/authorize.service';
import { VehicleStockItem } from 'src/app/models/vehicleStockItem';

@Component({
  selector: 'app-stock-details',
  templateUrl: './stock-details.component.html',
  styleUrls: ['./stock-details.component.css']
})
export class StockDetailsComponent implements OnInit, OnDestroy {
  paramsSubscription: Subscription
  // id: number;
  stockItem: VehicleStockItem;

  constructor(private route: ActivatedRoute, private authorizeService: AuthorizeService) { }

  ngOnInit() {
    this.stockItem = this.route.snapshot.params['id'];
    this.paramsSubscription = this.route.params.subscribe(
      (params: Params) => {
        this.stockItem = params['id'];
      }
    );
  }

  ngOnDestroy() {
    this.paramsSubscription.unsubscribe();
  }

  async onSaveDetails() {
    let userName = await this.authorizeService.getUser().pipe(map(u => u && u.name));
    // this.stockItem.createdBy = userName.tostring();
  }
}
