import {useState} from 'react';
import PropTypes from 'prop-types';
import useTransactionCategoriesApi from "../../../services/api/transactionCategories.jsx";

const AddCategoryForm = ({budgetPlanId, handleAction}) => {
    const {addOverTransactionCategory} = useTransactionCategoriesApi();

    const [categoryName, setCategoryName] = useState('');
    const [transactionType, setTransactionType] = useState(0);
    const thisBudgetPlanId = budgetPlanId;

    const handleAddCategory = async (event) => {
        try {
            event.preventDefault();
            await addOverTransactionCategory({
                BudgetPlanId: thisBudgetPlanId,
                Name: categoryName,
                TransactionType: transactionType
            });
            handleAction();
            setCategoryName('');
        } catch (error) {
            console.error('Error adding transaction category:', error);
        }
    };

    return (

        <div className={'col-3'}>
            <div className={'card'} style={{
                height: '100%'
            }}>
                <form onSubmit={handleAddCategory}>
                    <div className={'card-header'}>
                        <div className={'input-group input-group-sm'}>
                            <input type="text" className="form-control" value={categoryName}
                                   onChange={(e) => setCategoryName(e.target.value)}/>
                            <select className="form-select" id="inputGroupSelect" value={transactionType}
                                    onChange={(e) => setTransactionType(Number(e.target.value))}>
                                <option value={0}>Wpływy</option>
                                <option value={1}>Wydatki</option>
                            </select>
                            <button className="btn btn-outline-success" type="submit">Utwórz</button>
                        </div>
                    </div>
                    <div className={'card-body text-center'}>
                    </div>
                </form>
            </div>
        </div>

    )
        ;
};

AddCategoryForm.propTypes = {
    budgetPlanId: PropTypes.string.isRequired,
    handleAction: PropTypes.func.isRequired
};

export default AddCategoryForm;