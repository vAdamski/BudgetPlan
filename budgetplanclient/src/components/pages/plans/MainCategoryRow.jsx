import { useState } from "react";
import TransactionOffcanvas from "./TransactionOffcanvas";
import './MainCategoryRow.css';
import useBudgetPlanDetailsApi from "../../../services/api/budgetPlanDetails.jsx";
import {formatNumber} from "../../../services/helpers/utils.jsx";

function MainCategoryRow({ mainCategory, handleUpdateBudgetPlanBase }) {
    const { updateBudgetPlanDetailAllocatedAmount } = useBudgetPlanDetailsApi();

    const [show, setShow] = useState(false);
    const [selectedDay, setSelectedDay] = useState(null);
    const [transactionCategoryId, setTransactionCategoryId] = useState(null);
    const [editingSubCategoryId, setEditingSubCategoryId] = useState(null);
    const [editedAmount, setEditedAmount] = useState(null);
    const [editingBudgetPlanId, setEditingBudgetPlanId] = useState(null);


    const handleClose = () => setShow(false);
    const handleShow = (day, transactionCategoryId) => {
        setSelectedDay(day);
        setTransactionCategoryId(transactionCategoryId);
        setShow(true);
    };

    const handleAmountClick = (subCategoryId, amount, budgetPlanId) => {
        setEditingSubCategoryId(subCategoryId);
        setEditedAmount(amount);
        setEditingBudgetPlanId(budgetPlanId);
    };

    const handleAmountChange = (event) => {
        setEditedAmount(event.target.value);
    };

    const handleAmountBlur = async (subCategoryId) => {
        setEditingSubCategoryId(null);

        const dto = {
            id: subCategoryId,
            expectedAmount: editedAmount
        };

        try {
            await updateBudgetPlanDetailAllocatedAmount(dto);
            handleUpdateBudgetPlanBase();
        } catch (error) {
            console.error('Error updating budget plan detail:', error);
        }
    };

    return (
        <>
            <tr>
                <td className={'text-left text-bold fixed-width'}>
                    {mainCategory.transactionCategoryName}
                </td>
                <td className={'text-center fixed-width'}>
                    {formatNumber(mainCategory.plannedAmount)}
                </td>
                <td className={'text-center fixed-width'}>
                    {formatNumber(mainCategory.realAmount)}
                </td>
                <td className={'text-center fixed-width'}>
                    {formatNumber(mainCategory.difference)}
                </td>
            </tr>
            {mainCategory.subTransactionCategoryDetailsViewDtos.map(subCategory => (
                <tr key={subCategory.subCategoryId}>
                    <td className={'text-left fixed-width'}>
                        {subCategory.subCategoryName || ''}
                    </td>
                    <td
                        className={'text-center fixed-width'}
                        onClick={() => handleAmountClick(subCategory.subCategoryId, subCategory.budgetPlanDetailsDto.amountAllocated, subCategory.budgetPlanDetailsDto.id)}
                    >
                        {editingSubCategoryId === subCategory.subCategoryId ? (
                            <input
                                type="number"
                                value={editedAmount}
                                onChange={handleAmountChange}
                                onBlur={() => handleAmountBlur(subCategory.budgetPlanDetailsDto.id)}
                                className="fixed-width-input"  // Apply CSS class to the input
                                autoFocus
                            />
                        ) : (
                            formatNumber(subCategory.budgetPlanDetailsDto.amountAllocated)
                        )}
                    </td>
                    <td className={'text-center fixed-width'}>
                        {formatNumber(subCategory.budgetPlanDetailsDto.sumAmountOfAllDay)}
                    </td>
                    <td className={'text-center fixed-width'}>
                        {formatNumber(subCategory.budgetPlanDetailsDto.difference)}
                    </td>
                    <td>
                    </td>
                    {subCategory.budgetPlanDetailsDto.transactionItemsForDaysDtos.map(day => (
                        <td key={day.date} className={'fixed-width'}>
                            <div style={{ cursor: 'pointer' }} className={'text-center'} onClick={() => handleShow(day, subCategory.subCategoryId)}>
                                {formatNumber(day.sumAmountOfTheDay)}
                            </div>
                        </td>
                    ))}
                </tr>
            ))}
            <TransactionOffcanvas
                show={show}
                handleClose={handleClose}
                transactionCategoryId={transactionCategoryId}
                selectedDay={selectedDay}
                handleUpdate={handleUpdateBudgetPlanBase}
            />
        </>
    );
}

export default MainCategoryRow;