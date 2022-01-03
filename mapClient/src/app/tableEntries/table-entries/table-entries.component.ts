import { Component, Input, OnInit } from '@angular/core';
import { User } from 'src/app/Entites/User';

@Component({
  selector: 'app-table-entries',
  templateUrl: './table-entries.component.html',
  styleUrls: ['./table-entries.component.css'],
})
export class TableEntriesComponent implements OnInit {
  @Input() user!: User;
  constructor() {}

  ngOnInit(): void {}
}
