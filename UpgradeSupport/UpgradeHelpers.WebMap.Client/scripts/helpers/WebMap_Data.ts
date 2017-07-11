/// <reference path="kendo.all.d.ts" />
/// <reference path="jquery.blockUI.d.ts" />
/// <reference path="jquery.d.ts" />
/// <reference path="WebMap_Interfaces.ts" />

module WebMap.Client {
    
    // DataBinding: stores a list of Bindings and provides common operations

    class DataBinding {
        private bindings: Binding[];

        constructor() {
            this.bindings = new Array<Binding>();
        }

        public addBinding(propertyName: string, dataSource: DataSource, memberName: string): void {
            var newBinding = new Binding();
            newBinding.propertyName = propertyName;
            newBinding.dataSource = dataSource;
            newBinding.memberName = memberName;
            this.bindings.push(newBinding);
        }
    }

    class Binding {
        propertyName: string;
        dataSource: DataSource;
        memberName: string;
    }

    // DataSource: stores a "RecordSet" with the common operations

    class DataSource {
        private data: DataRow[];
        private index: number;
        private page: number;
        private id: number;

        constructor() {
            this.data = new Array<DataRow>();
            this.index = 0;
            this.page = 1;
        }

        public loadData(rsJSON): void {
			//This function is not working as expected
			// the rsJSON is not being used, the array is for output
			// It was corrected to properly compile in TS 1.8
            var dataRows = new Array<DataRow>();
            for (var i = 0; i < dataRows.length; i++) {
                var row = dataRows[i];
                var dataRow = new DataRow();
                var dataCells = new Array<DataCell>();
                var currentrow: any = row;
                for (var cell in currentrow) {
                    var dataCell = new DataCell();
                    // TODO: review
                    dataCell.propertyName = cell;
                    dataCell.value = row[cell];
                    dataCells.push(dataCell);
                }
                dataRow.cells = dataCells;
                dataRows.push(dataRow);
            }
            this.data = dataRows;
        }

        public refresh(): void {
            //TODO
        }
        public update(): void {
            //TODO
        }
    }

    class DataRow {
        cells: DataCell[];
    }

    class DataCell {
        propertyName: string;
        value: any;
    }
}
