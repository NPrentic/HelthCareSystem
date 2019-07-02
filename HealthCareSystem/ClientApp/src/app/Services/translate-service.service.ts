import { MatPaginatorIntl } from '@angular/material';

const RangeLabel = (page: number, pageSize: number, length: number) => {
  if (length == 0 || pageSize == 0) { return `0 od ${length}`; }

  length = Math.max(length, 0);

  const startIndex = page * pageSize;

  // If the start index exceeds the list length, do not try and fix the end index to the end.
  const endIndex = startIndex < length ?
    Math.min(startIndex + pageSize, length) :
    startIndex + pageSize;

  return `${startIndex + 1} - ${endIndex} od ${length}`;
}
export function translatePaginatorIntl() {
  const paginatorIntl = new MatPaginatorIntl();

  paginatorIntl.itemsPerPageLabel = 'Broj stavki po stranici:';
  paginatorIntl.nextPageLabel = 'Sljedeća';
  paginatorIntl.previousPageLabel = 'Prethodna';
  paginatorIntl.getRangeLabel = RangeLabel;

  return paginatorIntl;
}
