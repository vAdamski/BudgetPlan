import './plans.css';

function MainCategoryRow({mainCategory}) {

    return (
        <>
            <tr>
                <td className={'fitwidth text-left text-bold'}>
                    {mainCategory.transactionCategoryName}
                </td>
                <td className={'fitwidth'}>
                    {mainCategory.plannedAmount}
                </td>
                <td className={'fitwidth'}>
                    {mainCategory.realAmount}
                </td>
                <td className={'fitwidth'}>
                    {mainCategory.difference}
                </td>
                <td className={'fitwidth'}>

                </td>
            </tr>
            {mainCategory.subTransactionCategoryDetailsViewDtos.map(subCategory => (
                <tr key={subCategory.subCategoryId}>
                    <td className={'fitwidth text-left'}>
                        {subCategory.subCategoryName || ''}
                    </td>
                    <td className={'fitwidth'}>
                        {subCategory.budgetPlanDetailsDto.amountAllocated}
                    </td>
                    <td className={'fitwidth'}>
                        {subCategory.budgetPlanDetailsDto.sumAmountOfAllDay}
                    </td>
                    <td className={'fitwidth'}>
                        {subCategory.budgetPlanDetailsDto.difference}
                    </td>
                    <td className={'fitwidth'}>

                    </td>
                    {subCategory.budgetPlanDetailsDto.transactionItemsForDaysDtos.map(day => (
                        <td key={day.date}>
                            {day.sumAmountOfTheDay}
                        </td>
                    ))}
                </tr>
            ))}
        </>
    )
}


export default MainCategoryRow;