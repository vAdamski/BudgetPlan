import {useState} from "react";
import TransactionOffcanvas from "./TransactionOffcanvas";

function MainCategoryRow({mainCategory}) {
    const [show, setShow] = useState(false);
    const [selectedDay, setSelectedDay] = useState(null);
    const [transactionCategoryId, setTransactionCategoryId] = useState(null);

    const handleClose = () => setShow(false);
    const handleShow = (day, transactionCategoryId) => {
        setSelectedDay(day);
        setTransactionCategoryId(transactionCategoryId);
        setShow(true);
    };

    return (
        <>
            <tr>
                <td className={'text-left text-bold'}>
                    {mainCategory.transactionCategoryName}
                </td>
                <td className={'text-center'}>
                    {mainCategory.plannedAmount}
                </td>
                <td className={'text-center'}>
                    {mainCategory.realAmount}
                </td>
                <td className={'text-center'}>
                    {mainCategory.difference}
                </td>
            </tr>
            {mainCategory.subTransactionCategoryDetailsViewDtos.map(subCategory => (
                <tr key={subCategory.subCategoryId}>
                    <td className={'text-left'}>
                        {subCategory.subCategoryName || ''}
                    </td>
                    <td className={'text-center'}>
                        {subCategory.budgetPlanDetailsDto.amountAllocated}
                    </td>
                    <td className={'text-center'}>
                        {subCategory.budgetPlanDetailsDto.sumAmountOfAllDay}
                    </td>
                    <td className={'text-center'}>
                        {subCategory.budgetPlanDetailsDto.difference}
                    </td>
                    <td>
                    </td>
                    {subCategory.budgetPlanDetailsDto.transactionItemsForDaysDtos.map(day => (
                        <td key={day.date}>
                            <div style={{cursor: 'pointer'}} className={'text-center'} onClick={() => handleShow(day, subCategory.subCategoryId)}>
                                {day.sumAmountOfTheDay}
                            </div>
                        </td>
                    ))}
                </tr>
            ))}
            <TransactionOffcanvas
                show={show}
                handleClose={handleClose}
                transactionCategoryId = {transactionCategoryId}
                selectedDay={selectedDay}
            />
        </>
    );
}

export default MainCategoryRow;