import PropTypes from "prop-types";

const TableHeader = ({ dateFrom, dateTo }) => {
    const generateDateRange = (start, end) => {
        const dateArray = [];
        let currentDate = new Date(start);
        const stopDate = new Date(end);

        while (currentDate <= stopDate) {
            dateArray.push(new Date(currentDate));
            currentDate.setDate(currentDate.getDate() + 1);
        }

        return dateArray;
    };

    const formatDate = (date) => {
        const day = String(date.getDate()).padStart(2, '0');
        const month = String(date.getMonth() + 1).padStart(2, '0');
        return `${day}.${month}`;
    };

    const dates = generateDateRange(dateFrom, dateTo);

    return (
        <thead className={'text-center'}>
        <tr>
            <th className={'category-td'}>Kategoria</th>
            <th>Oczekiwane</th>
            <th>Aktualne</th>
            <th>Bilans</th>
            <th></th>
            {dates.map((date, index) => (
                <th key={index}>{formatDate(date)}</th>
            ))}
        </tr>
        </thead>
    );
};

TableHeader.propTypes = {
    dateFrom: PropTypes.string.isRequired,
    dateTo: PropTypes.string.isRequired,
};

export default TableHeader;