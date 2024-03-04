// File: robjam1990/Psychosis/Middleware/middleware.ts
// middleware.ts

import { Dispatch, Middleware, MiddlewareAPI } from 'redux';
import * as Actions from '../core/action-types';
import { RootState, Action } from '../types'; // Define RootState and Action types based on your Redux setup

/**
 * Log Middleware
 * Manages the log object.
 */
export const LogMiddleware: Middleware<{}, RootState> =
    (store: MiddlewareAPI) =>
        (next: Dispatch<Action>) =>
            (action: Action) => {
                const result = next(action);
                const state = store.getState();

                switch (action.type) {
                    case Actions.MAKE_MOVE:
                    case Actions.GAME_EVENT:
                    case Actions.UNDO:
                    case Actions.REDO: {
                        const deltaLog = state.deltaLog;
                        // TODO: Manage log object based on action type
                        break;
                    }

                    case Actions.RESET: {
                        // TODO: Reset log object
                        break;
                    }

                    case Actions.PATCH:
                    case Actions.UPDATE: {
                        // TODO: Update log object
                        break;
                    }

                    case Actions.SYNC: {
                        // TODO: Sync log object
                        break;
                    }

                    default: {
                        // No action needed for other types
                        break;
                    }
                }

                return result;
            };

/**
 * Transport Middleware
 * Intercepts actions and sends them to the master.
 * Handles error gracefully.
 */
export const TransportMiddleware: Middleware<{}, RootState> =
    (store: MiddlewareAPI) =>
        (next: Dispatch<Action>) =>
            async (action: Action) => {
                try {
                    await sendActionToMaster(action);
                } catch (error) {
                    console.error('Error sending action to master:', error);
                    // Optionally dispatch an error action or handle the error in another way
                } finally {
                    return next(action);
                }
            };

/**
 * Subscription Middleware
 * Intercepts actions and invokes the subscription callback.
 */
export const SubscriptionMiddleware: Middleware<{}, RootState> =
    (subscriptionCallback: (action: Action) => void) =>
        (next: Dispatch<Action>) =>
            (action: Action) => {
                subscriptionCallback(action);
                return next(action);
            };

// Helper function to send actions to the master
async function sendActionToMaster(action: Action) {
    // Implement your logic here (e.g., sending action via WebSocket or HTTP request)
    console.log('Sending action to master:', action);
}
