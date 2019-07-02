import { Pipe, PipeTransform } from '@angular/core';
import { DatePipe } from '@angular/common';

@Pipe({
  name: 'translateDate'
})
export class TranslateDatePipe implements PipeTransform {

  pipe = new DatePipe('en-US');

  transform(value: Date): string {

  var date =   this.pipe.transform(value, 'fullDate');

    var str = "";

    if (date != null) {
      str = date.toString();
      var array = str.split(" ");
      var day = array[0];
      if (day === 'Monday,') day = 'Ponedeljak,';
      if (day === 'Tuesday,') day = 'Utorak,';
      if (day === 'Wednesday,') day = 'Srijeda,';
      if (day === 'Thursday,') day = 'Četvrtak,';
      if (day === 'Friday,') day = 'Petak,';
      if (day === 'Saturday,') day = 'Subota,';
      if (day === 'Sunday,') day = 'Nedelja,';

      var month = array[1];

      if (month === 'January') month = 'januar';
      if (month === 'February') month = 'februar';
      if (month === 'March') month = 'mart';
      if (month === 'April') month = 'april';
      if (month === 'June') month = 'jun';
      if (month === 'July') month = 'jul';
      if (month === 'Avgust') month = 'avgust';
      if (month === 'September') month = 'septembar';
      if (month === 'October') month = 'oktobar';
      if (month === 'November') month = 'novembar';
      if (month === 'December') month = 'decembar';
      if (month === 'May') month = 'maj';

      array[2] = array[2].slice(0, -1);

      str = day + ' ' + array[2] + '. ' + month + ' ' + array[3] + '.';
    }
    return str;
  }

}
