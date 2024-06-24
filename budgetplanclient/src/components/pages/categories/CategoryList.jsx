import PropTypes from 'prop-types';
import SubCategoryList from './SubCategoryList';
import AddCategoryForm from './AddCategoryForm';

const CategoryList = ({ categories, handleAction }) => {
    return (
        <ul>
            {categories.map(budgetPlan => (
                <li key={budgetPlan.budgetPlanId}>
                    {budgetPlan.budgetPlanName}
                    <ul>
                        {budgetPlan.overTransactionCategoryList.map(category => (
                            <li key={category.id}>
                                {category.transactionCategoryName}
                                <SubCategoryList
                                    subCategories={category.transactionCategoryDtos}
                                    mainCategoryId={category.id}
                                    handleAction={handleAction}
                                />
                            </li>
                        ))}
                        <li>
                            <AddCategoryForm budgetPlanId={budgetPlan.budgetPlanId} handleAction={handleAction} />
                        </li>
                    </ul>
                </li>
            ))}
        </ul>
    );
};

CategoryList.propTypes = {
    categories: PropTypes.arrayOf(PropTypes.shape({
        budgetPlanId: PropTypes.string.isRequired,
        budgetPlanName: PropTypes.string.isRequired,
        overTransactionCategoryList: PropTypes.arrayOf(PropTypes.shape({
            id: PropTypes.string.isRequired,
            transactionCategoryName: PropTypes.string.isRequired,
            transactionCategoryDtos: PropTypes.arrayOf(PropTypes.shape({
                id: PropTypes.string.isRequired,
                transactionCategoryName: PropTypes.string.isRequired
            })).isRequired
        })).isRequired
    })).isRequired,
    handleAction: PropTypes.func.isRequired,
};

export default CategoryList;